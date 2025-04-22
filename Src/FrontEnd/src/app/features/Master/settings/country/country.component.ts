import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { GetCountryDto } from './Models/get-country.dto';
import { CountryService } from '../../../../services/country.service.service';
import { UpdateCountryDto } from './Models/update-country.dto';
import { CreateCountryDto } from './Models/create-country.dto';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule,FormsModule],
  styleUrls: ['./country.component.css']
})
export class CountryComponent implements OnInit {
  
  countryForm!: FormGroup;
  countries: GetCountryDto[] = [];
  showForm: boolean = false;
  isEditMode: boolean = false;
  selectedCountryId: number | null = null;

  constructor(private fb: FormBuilder, private countryService: CountryService) {}

  ngOnInit(): void {
    this.initForm();
    this.getCountries();
  }

  // Initialize the form
  private initForm(): void {
    this.countryForm = this.fb.group({
      countryName: ['', Validators.required],
      countryCode: ['', Validators.required],
      status: ['1', Validators.required],
    });
  }

  // Get the list of countries
  getCountries(): void {
    this.countryService.getAllCountries().subscribe({
      next: (countries: GetCountryDto[]) => {
        this.countries = countries;
      },
      error: (err) => {
        console.error('Error fetching countries:', err);
      }
    });
  }

  // Show or hide the form
  toggleForm(): void {
    this.showForm = !this.showForm;
    this.isEditMode = false;
    this.resetForm();
  }

  // Reset the form
  resetForm(): void {
    this.countryForm.reset({
      countryName: '',
      countryCode: '',
      status: '1', // Default to 'Active'
    });
    this.selectedCountryId = null;
  }

  // Submit the form (create or update)
  onSubmit(): void {
    if (this.countryForm.invalid) return;

    const statusValue = this.countryForm.value.status === '1' ? true : false; // Convert to 1 (Active) or 0 (Inactive)

    const countryDto = {
      countryId: this.selectedCountryId,
      countryName: this.countryForm.value.countryName,
      countryCode: this.countryForm.value.countryCode,
      countryStatus: statusValue, // Set the appropriate status value (0 or 1)
      updatedBy: 1  // Assuming 1 is hardcoded for now (this could be the logged-in user)
    };

    if (this.isEditMode && this.selectedCountryId !== null) {
      // Update existing country
      const updateDto: UpdateCountryDto = {
        ...countryDto,
        countryId: this.selectedCountryId as number 
      };
      console.log('Update Payload:', updateDto);

      this.countryService.updateCountry(updateDto).subscribe({
        next: () => {
          this.getCountries();
          this.resetForm();
          this.showForm = false;
        },
        error: (err) => console.error('Error updating country:', err),
      });
    } else {
      // Create new country
      const createDto: CreateCountryDto = {
        ...countryDto,
        createdBy: 1 // Assuming 1 is the ID of the creator (this could be the logged-in user)
      };

      this.countryService.createCountry(createDto).subscribe({
        next: () => {
          this.getCountries();
          this.resetForm();
          this.showForm = false;
        },
        error: (err) => console.error('Error creating country:', err),
      });
    }
  }

  // Edit an existing country
  onEdit(country: GetCountryDto): void {
    this.countryForm.patchValue({
      countryName: country.countryName,
      countryCode: country.countryCode,
      status: country.countryStatus.toString(),
    });

    this.selectedCountryId = country.countryId;
    this.showForm = true;
    this.isEditMode = true;
  }

  // onStatusChange(country: GetCountryDto): void {
  //   if (country.countryStatus === 0) {
  //     this.countryService.deleteCountry(country.id).subscribe({
  //       next: () => {
  //         this.getCountries(); 
  //       },
  //       error: (err) => {
  //         console.error('Error soft deleting country:', err);
  //       }
  //     });
  //   }
  // }
  onStatusChange(country: GetCountryDto): void {
    const confirmed = confirm(`Are you sure you want to mark "${country.countryName}" as Inactive?`);
    
    if (!confirmed) {
      // Revert toggle switch visually if user cancels
      country.countryStatus = 1;
      return;
    }
  console.log('country:', country);
    // Make API call to soft delete (set status = 0)
    this.countryService.softDeleteCountry(country.countryId).subscribe({
      next: () => {
        this.getCountries(); // Refresh the list after deletion
      },
      error: (err) => {
        console.error('Error soft deleting country:', err);
        country.countryStatus = 1; // revert in case of error
      }
    });
  }
  
  
  
  
}

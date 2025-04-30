import { AfterViewInit, Component, ElementRef, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { LocationService } from '../../../../services/location.service';
import { GetLocationDto } from './Models/get-location.dto';
import { UpdateLocationDto } from './Models/update-location.dto';
import * as bootstrap from 'bootstrap';
import { CreateLocationDto } from './Models/create-location.dto';
import { GetCityDto } from '../../settings/city/Models/get-city.dto';
import { CityService } from '../../../../services/city.service';
import { StateService } from '../../../../services/state.service';
import { CountryService } from '../../../../services/country.service.service';
import { GetCountryDto } from '../country/Models/get-country.dto';
import { GetStateDto } from '../state/Models/get-state.dto';

@Component({
  selector: 'app-location',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule],
  templateUrl: './location.component.html',
  styleUrl: './location.component.css'
})
export class LocationComponent implements OnInit, AfterViewInit {

  locationForm!: FormGroup;
    countries: GetCountryDto[] = [];
    states: GetStateDto[] = [];
    cities: GetCityDto[] = [];
    Locations:GetLocationDto[] =[];
    filteredStates: GetStateDto[] = []; 
    
    filteredCities: GetCityDto[] = []; 
    selectedlocationId: number | null = null;

    isEditMode = false;
  private locationModal!: bootstrap.Modal ;
  private modalElement: ElementRef | undefined;
  cityForm: any;


  constructor(
    private fb: FormBuilder,
    private locationService: LocationService,
    private cityService: CityService,
    private stateService: StateService,
    private countryService: CountryService,
    private el: ElementRef
  ) { }
  ngOnInit(): void {
    this.initForm();
    this.loadCountries();
    this.loadStates();
    this.loadCities();
    this.loadLocations();
  }


  ngAfterViewInit(): void {
    this.modalElement = this.el.nativeElement.querySelector('#locationModal');
    if (this.modalElement) {
      this.locationModal = new bootstrap.Modal(this.modalElement as unknown as Element);
    }
  }

  initForm(): void {
    this.locationForm = this.fb.group({
      countryId: ['', Validators.required],
      stateId: ['', Validators.required],
      cityId: ['', Validators.required],
      locationName: ['', Validators.required],
      locationStatus: ['1', Validators.required],
    });
  }

  loadCountries(): void {
    this.countryService.getAllCountries().subscribe(res => this.countries = res);
  }
  loadStates(): void {
    this.stateService.getAllStates().subscribe(res => this.states = res);
  }

  loadCities(): void {
    this.cityService.getAllCities().subscribe(res => { this.cities = res;
      console.log("This is response: ",this.cities);
      this.filterStates();


    });

  }
  loadLocations(): void {
    this.locationService.getAllLocations().subscribe(res => this.Locations = res);
    console.log(this.cities)
  }
  
  filterStates(): void {
    const countryId = +this.locationForm.get('countryId')?.value;
    console.log('Selected CountryId:', countryId);
    this.filteredStates = this.states.filter(s => s.countryId === countryId);
  }

 

filterCities(): void {
  const stateId = +this.locationForm.get('stateId')?.value;
  this.filteredCities = this.cities.filter(c => c.stateId === stateId);
  console.log(this.filteredCities);

}
onStateChange(): void {
  this.filterCities();
  this.locationForm.patchValue({ cityId: '' });
}


  onCountryChange(): void {
    this.filterStates();
  }
  openAddModal(): void {
    this.resetForm();
    this.isEditMode = false;

    this.locationModal.show();
  }
  
   onEdit(location: GetLocationDto): void {
      this.locationForm.patchValue({
        countryId: location.countryId,
        stateId: location.stateId,
        cityId: location.cityId,
        locationName: location.locationName,
        locationCode:location.locationCode,
        locationstatus: location.locationStatus ? '1' : '0',
      });
      this.selectedlocationId = location.locationId;
      this.isEditMode = true;
      this.filterStates();
      this.filterCities();
      this.locationModal.show();
      console.log(location.cityName);
      
    }


    onSubmit(): void {
        if (this.locationForm.invalid) {
          console.log("hello world")
          return;}
        const statusBool = this.locationForm.value.locationStatus === '1' ? true : false;
        const cityid = +this.locationForm.value.cityId;
        const payload = {
          locationName: this.locationForm.value.locationName,
          cityId: cityid,
          locationStatus: statusBool,
    
        };
        
        if (this.isEditMode && this.selectedlocationId) {
          const updateDto: UpdateLocationDto = { ...payload, locationId: this.selectedlocationId, updatedBy: 1 };
          this.locationService.updateLocation(updateDto).subscribe({
            next:()=>{
                this.loadLocations();
                this.resetForm();
            },
            error:(error) => {
              console.log("Ooooooo",error);
            }
          });

        }
         else {
          const createDto: CreateLocationDto = {...payload, createdBy: 1 };
          this.locationService.createLocation(createDto).subscribe({
            next:()=>{
              this.loadLocations();
              this.resetForm();
          },
          error:(error) => {
            console.log("Ooooooo",error);
          }
          });
          
        }
        }
      

      resetForm(): void {
        this.locationForm.reset({ countryId: '', stateId: '',cityId:'', loationName: '',locationCode:'', locationStatus:'1' });
        this.selectedlocationId = null;
      }
      onStatusChange(location: GetLocationDto): void {
          const confirmed = confirm(`Are you sure you want to mark "${location.locationName}" as ${location.locationStatus ? 'Inactive' : 'Active'}?`);
      
          if (!confirmed) {
            this.loadLocations(); 
            return;
          }
      
          const newStatus = location.locationStatus ? 0 : 1; 
      
          this.locationService.softDeleteLocation(location.locationId, newStatus).subscribe({
            next: () => {
              this.loadLocations(); 
            },
            error: (err) => {
              console.error('Error updating Location status:', err);
              this.loadCities(); 
            }
          });
        }
      }
      
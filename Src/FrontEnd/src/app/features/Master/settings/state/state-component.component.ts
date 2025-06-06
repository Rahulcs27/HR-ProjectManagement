import { Component, OnInit, AfterViewInit, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import * as bootstrap from 'bootstrap';

import { StateService } from '../../../../services/state.service';
import { CountryService } from '../../../../services/country.service.service';
import { GetStateDto } from './Models/get-state.dto';
import { GetCountryDto } from '../country/Models/get-country.dto';
import { UpdateStateDto } from './Models/update-state.dto';
import { CreateStateDto } from './Models/create-state.dto';
import { NgxPaginationModule } from 'ngx-pagination';

@Component({
  selector: 'app-state',
  templateUrl: './state-component.component.html',
  standalone: true,
  styleUrls: ['./state-component.component.css'],
  imports: [CommonModule, ReactiveFormsModule, FormsModule,NgxPaginationModule],
})
export class StateComponent implements OnInit, AfterViewInit {
  stateForm!: FormGroup;
  states: GetStateDto[] = [];
  countries: GetCountryDto[] = [];
  

  isEditMode = false;
  selectedStateId: number | null = null;
  searchText: string = '';
  filteredStates: any[] = [];
  currentPage: number = 1;
itemsPerPageOptions: number[] = [3, 5, 10, 25]
itemsPerPage: number = 5; // default value

  private stateModal!: bootstrap.Modal;
  private modalElement: ElementRef | undefined;

  constructor(
    private fb: FormBuilder,
    private stateService: StateService,
    private countryService: CountryService,
    private el: ElementRef
  ) {}

  ngOnInit(): void {
    this.initForm();
    this.loadStates();
    this.loadCountries();
  }

  ngAfterViewInit(): void {
    this.modalElement = this.el.nativeElement.querySelector('#stateModal');
    if (this.modalElement) {
      this.stateModal = new bootstrap.Modal(this.modalElement as unknown as Element);
    }
  }

  initForm(): void {
    this.stateForm = this.fb.group({
      countryId: ['', Validators.required],
      stateName: ['', Validators.required],
      stateCode: ['', Validators.required],
      stateStatus: ['1', Validators.required],
    });
  }

  
  loadStates(): void {
    this.stateService.getAllStates().subscribe((data) => {
      this.states = data;
      this.filteredStates = [...data]; 
    });
  }

  loadCountries(): void {
    this.countryService.getAllCountries().subscribe({
      next: (data) => (this.countries = data),
      error: (err) => console.error('Error loading countries:', err),
    });
  }
  filterStates(): void {
    const search = this.searchText?.trim().toLowerCase();
  
    if (!search) {
      this.filteredStates = [...this.states];
      return;
    }
  
    this.filteredStates = this.states.filter(s =>
      s.stateName.toLowerCase().includes(search)
    );
  }

  openAddModal(): void {
    this.resetForm();
    this.isEditMode = false;
    this.stateModal.show();
  }
  resetForm(): void {
    this.stateForm.reset({
      countryId: '',
      stateName: '',
      stateCode: '',
      stateStatus: '1',
    });
    this.selectedStateId = null;
    this.isEditMode = false;
  }

  onEdit(state: GetStateDto): void {
    this.stateForm.patchValue({
      countryId: state.countryId,
      stateName: state.stateName,
      stateCode: state.stateCode,
      stateStatus: state.stateStatus ? '1' : '0',
    });
    this.selectedStateId = state.stateId;
    this.isEditMode = true;
    this.stateModal?.show();
  }
  onSubmit(): void {
    if (this.stateForm.invalid) return;

    const statusBool = this.stateForm.value.stateStatus === '1' ? true : false;
    console.log(this.stateForm.value.countryId, this.stateForm.value.stateName,this.stateForm.value.stateCode, this.stateForm.value.stateStatus);
    const statePayload = {
      stateId: this.selectedStateId,
      countryId: this.stateForm.value.countryId,
      stateName: this.stateForm.value.stateName,
      stateCode: this.stateForm.value.stateCode,
      stateStatus: statusBool,
      updatedBy: 1
    };
    const CreateStatePayload = {
      countryId: this.stateForm.value.countryId,
      stateName: this.stateForm.value.stateName,
      stateCode: this.stateForm.value.stateCode
    };

    if (this.isEditMode && this.selectedStateId !== null) {
      let updateDto: UpdateStateDto | undefined;
      if (this.selectedStateId !== null) {
        updateDto = { ...statePayload, stateId: this.selectedStateId, updatedBy: 1 };
      }
      if (updateDto) {
        console.log("Checkcheck");
        
        this.stateService.updateState(updateDto).subscribe({
        next: () => {
          this.loadStates();
          this.resetForm();
          // this.stateModal?.hide();
        },
        error: (err) => console.error('Update error:', err),
      });
    }}
    else {
          const createDto: CreateStateDto = {
            ...CreateStatePayload,
            createdBy: 1
          };
    
          this.stateService.createState(createDto).subscribe({
            next: () => {
              this.loadStates();
              this.resetForm();
              // this.stateModal?.hide();
            },
            error: (err) => console.error('Error creating state:', err),
          });
        }
  }
  onStatusChange(state: GetStateDto): void {
    const confirmed = confirm(`Are you sure you want to mark "${state.stateName}" as ${state.stateStatus ? 'Inactive' : 'Active'}?`);

    if (!confirmed) {
      this.loadStates(); 
      return;
    }

    const newStatus = state.stateStatus ? 0 : 1; 

    this.stateService.softDeleteState(state.stateId, newStatus).subscribe({
      next: () => {
        this.loadStates(); 
      },
      error: (err) => {
        console.error('Error updating country status:', err);
        this.loadStates(); 
      }
    });
  }
}

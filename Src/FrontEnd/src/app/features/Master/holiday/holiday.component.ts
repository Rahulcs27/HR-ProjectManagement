import { Component, OnInit, ElementRef, AfterViewInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import * as bootstrap from 'bootstrap';
import { GetHolidayDto } from './Models/get-holiday.dto';
import { HolidayService } from '../../../services/holiday.service';
import { UpdateHolidayDto } from './Models/update-holiday.dto';
import { CreateHolidayDto } from './Models/create-holiday.dto';
import { CommonModule } from '@angular/common';
import { DatePickerModule } from 'primeng/datepicker';
@Component({
  selector: 'app-holiday',
  templateUrl: './holiday.component.html',
  styleUrls: ['./holiday.component.css'],
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule,DatePickerModule],

})
export class HolidayComponent implements OnInit, AfterViewInit {
  holidayForm!: FormGroup;
  holidays: GetHolidayDto[] = [];
  filteredResults: GetHolidayDto[] = [];
  selectedHolidayId: number | null = null;
  isEditMode = false;
  private modal!: bootstrap.Modal;

  filter = {
    listType: '',
    year: new Date().getFullYear()
  };

  // onYearPicked(date: { year: number; month: number; day: number }) {
  //   this.filter.year = date.year;
  //   console.log('Selected year:', this.filter.year);
  // }
  filterYear: Date = new Date(); 
  filternewYear: Date = new Date();

  onYearSelect(event: Date): void {
    const selectedYear = event.getFullYear();
    this.filter.year = selectedYear;
    console.log('Selected year:', selectedYear);
  }
    
  
  
  

  constructor(
    private fb: FormBuilder,
    private holidayService: HolidayService,
    private el: ElementRef
  ) {}

  ngOnInit(): void {
    this.initForm();
    this.loadHolidays();
  }

  ngAfterViewInit(): void {
    const modalEl = this.el.nativeElement.querySelector('#holidayModal');
    if (modalEl) {
      this.modal = new bootstrap.Modal(modalEl);
    }
  }

  initForm(): void {
    this.holidayForm = this.fb.group({
      holidayName: ['', Validators.required],
      holidayDate: ['', Validators.required],
      holidayListType: ['1', Validators.required],
      year: [new Date().getFullYear(), Validators.required],
      holidayStatus: [1, Validators.required]
    });
  }

  formatHolidayDate(date: string): string {
    const d = new Date(date);
    const options: Intl.DateTimeFormatOptions = { day: 'numeric', month: 'long' };
    return d.toLocaleDateString('en-GB', options);
  }

  getDayName(date: string): string {
    return new Date(date).toLocaleDateString('en-GB', { weekday: 'long' });
  }

  loadHolidays(): void {
    this.holidayService.getAllHolidays().subscribe(res => {
      this.holidays = res.map(h => ({
        ...h,
        dayName: this.getDayName(h.holidayDate),
        formattedDate: this.formatHolidayDate(h.holidayDate)
      }));
      console.log('Holidays:', this.holidays);
      this.filterHolidays();
    });
  }

  filterHolidays(): void {
    this.filteredResults = this.holidays.filter(h =>
      (this.filter.listType === '' || h.holidayListType === (this.filter.listType === '1')) &&
      (!this.filter.year || h.year === +this.filter.year)
    );
  }

  openAddModal(): void {
    this.resetForm();
    this.isEditMode = false;
    this.modal.show();
  }

  onEdit(h: GetHolidayDto): void {
    console.log('Editing holiday:', h);
    this.holidayForm.patchValue({
      holidayName: h.holidayName,
      holidayDate: h.holidayDate,
      holidayListType: h.holidayListType ? '1' : '0',
      year: h.year,
      holidayStatus: h.holidayStatus ? '1' : '0'

    });
    console.log('Holiday Form Values:', this.holidayForm.value);
    this.selectedHolidayId = h.holidayId;
    this.isEditMode = true;
    this.modal.show();
  }

  onSubmit(): void {
    if (this.holidayForm.invalid) return;

    const payload = {
      holidayName: this.holidayForm.value.holidayName,
      holidayDate: this.holidayForm.value.holidayDate,
      holidayListType: this.holidayForm.value.holidayListType === '1',
      year: +this.holidayForm.value.year,
      holidayStatus: this.holidayForm.value.holidayStatus === '1' ? true : false,
    };

    if (this.isEditMode && this.selectedHolidayId) {
      const dto: UpdateHolidayDto = { ...payload, holidayId: this.selectedHolidayId, updatedBy: 1 };
      this.holidayService.updateHoliday(dto).subscribe(() => {
        this.loadHolidays();
        this.modal.hide();
      });
      console.log('Update Payload:', dto);
    } else {
      const dto: CreateHolidayDto = { ...payload, createdBy: 1 };
      this.holidayService.createHoliday(dto).subscribe(() => {
        this.loadHolidays();
        this.modal.hide();
      });
    }
  }

  resetForm(): void {
    this.holidayForm.reset({
      holidayName: '',
      holidayDate: '',
      holidayListType: '1',
      year: new Date().getFullYear(),
      holidayStatus: '1'
    });
    this.selectedHolidayId = null;
  }

  onStatusChange(holiday: GetHolidayDto): void {
      const confirmed = confirm(`Are you sure you want to mark "${holiday.holidayName}" as ${holiday.holidayStatus ? 'Inactive' : 'Active'}?`);
  
      if (!confirmed) {
        this.loadHolidays(); 
        return;
      }
  
      const newStatus = holiday.holidayStatus ? 0 : 1; 
  
      this.holidayService.softDeleteHoliday(holiday.holidayId, newStatus).subscribe({
        next: () => {
          this.loadHolidays(); 
        },
        error: (err) => {
          console.error('Error updating Holiday status:', err);
          console.log('holiday id delete:', holiday.holidayId);

          this.loadHolidays(); 
        }
      });
    }
  
}

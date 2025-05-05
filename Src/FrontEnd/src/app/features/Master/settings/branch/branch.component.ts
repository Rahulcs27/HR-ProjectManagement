import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { Branch } from '../../../../Models/branch-model';
import { BranchService } from '../../../../services/branch-service';
import { GetCityDto } from '../city/Models/get-city.dto';


@Component({
  selector: 'app-branch',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule, NgxPaginationModule, HttpClientModule],
  templateUrl: './branch.component.html',
  styleUrls: ['./branch.component.css']
})
export class BranchComponent implements OnInit {
  branchForm!: FormGroup;
  branches: Branch[] = [];
  filteredBranches: Branch[] = [];
  cities: GetCityDto[] = [];

  itemsPerPageOptions = [5, 10, 25, 50];
  itemsPerPage = 10;
  currentPage = 1;
  searchText = '';
  isEditMode = false;
  editBranchId: number | null = null;

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private branchService: BranchService
  ) {}

  ngOnInit(): void {
    this.initializeForm();
    this.loadCities();
    this.loadBranches();
  }

  initializeForm(): void {
    this.branchForm = this.fb.group({
      fk_CityId: ['', Validators.required],
      branchName: ['', Validators.required]
    });
  }

  loadCities(): void {
    this.http.get<GetCityDto[]>('/City').subscribe({
      next: (res) => this.cities = res,
      error: (err) => console.error('Error loading cities', err)
    });
  }

  loadBranches(): void {
    this.branchService.getBranches().subscribe({
      next: (res) => {
        this.branches = res;
        this.filteredBranches = [...this.branches];
      },
      error: (err) => console.error('Error loading branches', err)
    });
  }

  filterBranches(): void {
    const term = this.searchText.toLowerCase();
    this.filteredBranches = this.branches.filter(b =>
      b.branchName.toLowerCase().includes(term) ||
      b.cityName.toLowerCase().includes(term) ||
      b.stateName.toLowerCase().includes(term)
    );
  }

  onSubmit(): void {
    if (this.branchForm.invalid) return;

    const payload = {
      cityId: this.branchForm.value.fk_CityId,
      branchName: this.branchForm.value.branchName,
      createdBy: 1
    };

    if (this.isEditMode && this.editBranchId !== null) {
      // You can add update logic here in service when needed
    } else {
      this.branchService.addBranch(payload).subscribe({
        next: (newBranch) => {
          this.branches.push(newBranch);
          this.filteredBranches = [...this.branches];
          this.resetForm();
        },
        error: (err) => console.error('Error adding branch', err)
      });
    }
  }

  openAddBranchModal(): void {
    this.resetForm();
  }

  onEditBranch(branch: Branch): void {
    this.isEditMode = true;
    this.editBranchId = branch.branchId;

    this.branchForm.patchValue({
      fk_CityId: branch.cityId,
      branchName: branch.branchName
    });
  }

  resetForm(): void {
    this.branchForm.reset();
    this.isEditMode = false;
    this.editBranchId = null;
  }
}

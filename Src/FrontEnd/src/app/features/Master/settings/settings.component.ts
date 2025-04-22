import { Component } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { CountryComponent } from './country/country.component';
import { CommonModule } from '@angular/common';
import { SubcategoryTabsComponent } from '../../../shared/subcategory-tabs/subcategory-tabs.component';

@Component({
  selector: 'app-settings',
  imports: [ReactiveFormsModule,CountryComponent,CommonModule,SubcategoryTabsComponent],
  templateUrl: './settings.component.html',
  styleUrl: './settings.component.css'
})
export class SettingsComponent {
  activeTab = 'Country';

  onTabChanged(tab: string) {
    this.activeTab = tab;
  }

}

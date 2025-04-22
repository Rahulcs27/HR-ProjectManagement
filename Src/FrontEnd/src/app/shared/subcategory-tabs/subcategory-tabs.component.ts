import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-subcategory-tabs',
  templateUrl: './subcategory-tabs.component.html',
  imports: [CommonModule],
})
export class SubcategoryTabsComponent {
  tabs: string[] = [
    'Country',
    'State',
    'City',
    'Location',
    'Division',
    'Designation',
    'Drawing Property',
    'Project Complexity',
    'Project Type',
    'Shift Type',
    'Bde Prefix Mapping',
    'Owner Prefix Mapping',
    'Nature Of Drawing',
    'Mode Of Transmittal',
    'Transmittal Type',
    'Non Production Activity',
    'Break Hours Activity',
    'Progress Entry Date Range',
    'Currency',
    'Slab Price'
  ];

  selectedTab: string = 'Country';

  @Output() tabChanged = new EventEmitter<string>();

  selectTab(tab: string) {
    this.selectedTab = tab;
    this.tabChanged.emit(tab);
  }
}

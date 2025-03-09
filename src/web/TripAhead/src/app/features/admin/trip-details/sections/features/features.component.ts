import {Component} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';
import {TableModule} from 'primeng/table';
import {ButtonModule} from 'primeng/button';
import {DialogModule} from 'primeng/dialog';
import {InputTextModule} from 'primeng/inputtext';
import {CheckboxModule} from 'primeng/checkbox';
import {TooltipModule} from 'primeng/tooltip';
import {CardModule} from 'primeng/card';
import {ToolbarModule} from 'primeng/toolbar';
import {TagModule} from "primeng/tag";
import {RippleModule} from "primeng/ripple";
import {OptionalItem, OptionalItemCategory} from '../../../../../../types/optional-item';
import {AccordionModule} from "primeng/accordion";
import {InputNumber} from "primeng/inputnumber";
import {DropdownModule} from "primeng/dropdown";

@Component({
  selector: 'app-features',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    TableModule,
    ButtonModule,
    DialogModule,
    InputTextModule,
    CheckboxModule,
    TooltipModule,
    CardModule,
    ToolbarModule,
    TagModule,
    RippleModule,
    AccordionModule,
    InputNumber,
    DropdownModule
  ],
  templateUrl: './features.component.html',
  styleUrl: './features.component.scss'
})
export class FeaturesComponent {
  categories: string[] = ['equipment', 'insurance', 'transport', 'others'];
  categoriesOptions = [
    { label: 'equipment', value: 'EQUIPMENT' },
    { label: 'insurance', value: 'INSURANCE' },
    { label: 'transport', value: 'TRANSPORT' },
    { label: 'others', value: 'OTHERS' }
  ];
  optionalItems: OptionalItem[] = [
    {
      id: '1',
      name: 'Ubezpieczenie standard',
      description: 'Standardowe ubezpieczenie 100/12',
      price: 100,
      category: OptionalItemCategory.Insurance
    },
    {
      id: '2',
      name: 'Ubezpieczenie premium',
      description: 'Standardowe ubezpieczenie 100/12',
      price: 300,
      category: OptionalItemCategory.Insurance
    },
    {
      id: '3',
      name: 'Deska 156cm',
      description: 'Deska salomon 156cm',
      price: 400,
      category: OptionalItemCategory.Equipment
    }
  ];


  selectedCategory: OptionalItemCategory = OptionalItemCategory.Equipment;
  optionalItem: OptionalItem = this.createOptionalItem();
  featureDialog: boolean = false;

  getFilteredItems(category: string) {
    return this.optionalItems.filter(item => item.category === category);
  }

  createOptionalItem(): OptionalItem {
    return {
      id: '',
      name: '',
      description: '',
      price: 0,
      category: OptionalItemCategory.Equipment
    };
  }

  openNew() {
    this.optionalItem = this.createOptionalItem();
    this.featureDialog = true;
  }

  editOptionalItem(optionalItem: OptionalItem) {
    this.optionalItem = {...optionalItem};
    this.featureDialog = true;
  }

  deleteOptionalItem(optionalItem: OptionalItem) {
    this.optionalItems = this.optionalItems.filter(f => f.id !== optionalItem.id);
  }

  hideDialog() {
    this.featureDialog = false;
  }

  saveOptionalItem() {
    if (this.optionalItem.name.trim()) {
      if (this.optionalItem.id) {
        // Update existing feature
        this.optionalItems = this.optionalItems.map(f => (f.id === this.optionalItem.id) ? this.optionalItem : f);
      } else {
        // Create new feature with random ID
        this.optionalItem.id = this.createId();
        this.optionalItems.push(this.optionalItem);
      }

      this.featureDialog = false;
      this.optionalItem = this.createOptionalItem();
    }
  }

  trackById(index: number, item: OptionalItem): string {
    return item.id;
  }

  createId(): string {
    return Math.random().toString(36).substring(2, 9);
  }
}

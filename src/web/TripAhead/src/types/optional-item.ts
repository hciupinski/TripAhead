export interface OptionalItem {
  id: string
  category: OptionalItemCategory;
  name: string;
  description: string;
  price: number;
}

export enum OptionalItemCategory {
  Equipment = 'equipment',
  Insurance = 'insurance',
  Transport = 'transport',
  Other = 'other'
}

export interface Category {
  id: number;
  name: string;
  description: string;
  icon: string;
  classNames?: string;
}

export type SelectedCategory = Omit<
  Category,
  'description' | 'icon' | 'classNames'
>;

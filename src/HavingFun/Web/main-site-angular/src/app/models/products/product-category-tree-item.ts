export interface ProductCategoryTreeItem{
    label:string;
    data: number;
    expandedIcon: string;
    collapsedIcon: string;
    children: ProductCategoryTreeItem[]
}
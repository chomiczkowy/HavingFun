import { SortableQuery } from './sortable-query';

export interface PageableQuery extends SortableQuery{
    pageSize:number;
    pageNumber:number;
}
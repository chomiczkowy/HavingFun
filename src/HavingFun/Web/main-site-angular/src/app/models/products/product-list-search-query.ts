import { PageableQuery } from '../queries/pageable-query';

export interface ProductListSearchQuery extends PageableQuery{
    categoriesIds:number[];
}
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsersListComponent } from './features/users/users-list/users-list.component';
import { LoginComponent } from './features/login/login.component';
import { AuthGuard } from './infrastructure/auth.guard';

const routes: Routes = [
  {
    path:'user/list',
    component: UsersListComponent,
    canActivate: [AuthGuard]
  },
  {
    path:'login',
    component: LoginComponent
  },
  { path: '',
    redirectTo: '/login',
    pathMatch: 'full',
    canActivate: [AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

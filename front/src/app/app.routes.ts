import { Routes, RouterModule } from '@angular/router';

import {
  DashboardComponent,
  LoginComponent,
} from './main';

const AppRoutesList: Routes = [
  { path: '', component: DashboardComponent },
  { path: 'login', component: LoginComponent },
  { path: '**', redirectTo: '' }
];

export const AppRoutes = RouterModule.forRoot(AppRoutesList);

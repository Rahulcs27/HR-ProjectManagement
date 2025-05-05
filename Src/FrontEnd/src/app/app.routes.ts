import { Routes } from '@angular/router';
import { DashboardComponent } from './features/Dashboard/dashboard/dashboard.component';
import { LoginComponent } from './features/login/login.component';
import { OtpComponent } from './features/otp/otp.component';
import { SettingsComponent } from './features/Master/settings/settings.component';
import { ChangePasswordComponent } from './features/Profile/change-password/change-password.component';
import { LefSideNavComponent } from './shared/lef-side-nav/lef-side-nav.component';
import { GmcComponent } from './features/Master/gmc/gmc.component';
import { AuthGuard } from './auth.guard';
import { TimesheetUpdateComponent } from './features/Hr/timesheet-update/timesheet-update.component';

import { EmployeeComponent } from './features/Master/employee/employee.component';
import { EmployeeRegistrationComponent } from './features/Master/employee/employee-registration/employee-registration.component';

import { CountryComponent } from './features/Master/settings/country/country.component';
import { StateComponent } from './features/Master/settings/state/state-component.component';
import { HolidayComponent } from './features/Master/holiday/holiday.component';
import { TeamCompositionComponent } from './features/Master/team-composition/team-composition.component';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  // { path: 'otp', component: OtpComponent  },
  
  
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] },
  { path: 'settings', component: SettingsComponent, canActivate: [AuthGuard] },
  { path: 'changePassword', component: ChangePasswordComponent, canActivate: [AuthGuard] },
  { path: 'gmc', component: GmcComponent, canActivate: [AuthGuard] },
  { path: 'sidebar', component: LefSideNavComponent, canActivate: [AuthGuard] },
  { path: '**', redirectTo: '' },
  { path: '', component: LoginComponent },
  { path: 'team-composition', component: TeamCompositionComponent },
  { path: 'country', component: CountryComponent },
  { path: 'state', component: StateComponent },
  { path: 'holiday', component: HolidayComponent },
  { path: 'timesheetupdate', component: TimesheetUpdateComponent },
  { path: 'employee', component: EmployeeComponent },
  { path: 'employee-registration', component: EmployeeRegistrationComponent },
  { path: 'otp', component: OtpComponent },

];

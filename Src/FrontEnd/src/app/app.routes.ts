import { Routes } from '@angular/router';
import { DashboardComponent } from './features/Dashboard/dashboard/dashboard.component';
import { LoginComponent } from './features/login/login.component';
import { OtpComponent } from './features/otp/otp.component';
import { SettingsComponent } from './features/Master/settings/settings.component';
import { ChangePasswordComponent } from './features/Profile/change-password/change-password.component';
export const routes: Routes = [
    
        { path: 'dashboard',
         component: DashboardComponent,
          },
          {
            path: 'settings',
            component: SettingsComponent,
          },
          {path:"changePassword" ,component:ChangePasswordComponent,},
    { path:'',component:LoginComponent},
    {path:'otp',component:OtpComponent}

   

];

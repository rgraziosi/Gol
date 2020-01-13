import { Routes } from '@angular/router';
import { HomeComponent } from './core/pages/home/home.component';
import { AboutComponent } from './core/pages/about/about.component';

import { AirplaneComponent } from './core/pages/airplane-pages/airplane/airplane.component';
import { EditAirplaneComponent } from './core/pages/airplane-pages/edit-airplane/edit-airplane.component';
import { AddAirplaneComponent } from './core/pages/airplane-pages/add-airplane/add-airplane.component';
import { AddPassagerComponent } from './core/pages/passager-pages/add-passager/add-passager.component';
import { EditPassagerComponent } from './modules/passager/components/edit-passager/edit-passager.component';
import { FlightPassagerComponent } from './core/pages/passager-pages/flight-passager/flight-passager.component';
import { ListPassagerComponent } from './modules/passager/components/list-passager/list-passager.component';

export const APP_ROUTES: Routes = [
    {path: '', component: HomeComponent},
    {path: 'about', component: AboutComponent},
    {path: 'airplanes', component: AirplaneComponent},
    {path: 'edit-airplane/:id', component: EditAirplaneComponent},
    {path: 'new-airplane', component: AddAirplaneComponent}, 
    {path: 'passagers', component: ListPassagerComponent},
    {path: 'new-passager', component: AddPassagerComponent},
    {path: 'edit-passager/:id', component: EditPassagerComponent},
    {path: 'flight-passagers/:idAirplane', component: FlightPassagerComponent}
]
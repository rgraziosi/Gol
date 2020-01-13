import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HomeComponent } from './core/pages/home/home.component';

import { ToastrModule } from 'ngx-toastr';

import { AirplaneModule } from './modules/airplane/airplane.module';
import { AddAirplaneComponent } from './core/pages/airplane-pages/add-airplane/add-airplane.component';
import { AirplaneComponent } from './core/pages/airplane-pages/airplane/airplane.component';
import { EditAirplaneComponent } from './core/pages/airplane-pages/edit-airplane/edit-airplane.component';

import { PassagerModule } from './modules/passager/passager.module';
import { AddPassagerComponent } from './core/pages/passager-pages/add-passager/add-passager.component';
import { PassagerComponent } from './core/pages/passager-pages/passager/passager.component';
import { EditPassagerComponent } from './core/pages/passager-pages/edit-passager/edit-passager.component';
import { FlightPassagerComponent } from './core/pages/passager-pages/flight-passager/flight-passager.component';

// Shared
import { SharedModule } from './shared/shared.module';

// Services
import { SeoService } from './core/services/seo.service';
import { RouterModule } from '@angular/router';
import { APP_ROUTES } from './app.routes';
import { AboutComponent } from './core/pages/about/about.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    AddAirplaneComponent,
    AirplaneComponent,
    EditAirplaneComponent,
    PassagerComponent,
    AddPassagerComponent,
    EditPassagerComponent,
    FlightPassagerComponent
    
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(APP_ROUTES),
    ToastrModule.forRoot(),
    AirplaneModule,
    SharedModule,
    PassagerModule
  ],
  providers: [ SeoService ],
  bootstrap: [AppComponent]
})
export class AppModule { }

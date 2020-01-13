import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddPassagerComponent } from './components/add-passager/add-passager.component';
import { Title } from '@angular/platform-browser';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { PassagerService } from './services/passager.service';
import { HttpClientModule } from '@angular/common/http';
import { FlightPassagerComponent } from './components/flight-passager/flight-passager.component';
import { MyDatePickerModule } from 'mydatepicker';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ListPassagerComponent } from './components/list-passager/list-passager.component';
import { RouterModule } from '@angular/router';
import { EditPassagerComponent } from './components/edit-passager/edit-passager.component';
import { AirplaneModule } from '../airplane/airplane.module';
import { SeoService } from '../../core/services/seo.service';

@NgModule({
  declarations: [AddPassagerComponent, ListPassagerComponent, EditPassagerComponent, FlightPassagerComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    MyDatePickerModule,
    BrowserAnimationsModule,
    RouterModule,
    AirplaneModule
  ],
  providers: [
    Title,
    SeoService,
    PassagerService
  ],
  exports: [AddPassagerComponent, ListPassagerComponent, EditPassagerComponent, FlightPassagerComponent]
})
export class PassagerModule { }

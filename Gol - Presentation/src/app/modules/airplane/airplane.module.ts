import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddAirplaneComponent } from './components/add-airplane/add-airplane.component';
import { Title } from '@angular/platform-browser';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AirplaneService } from './services/airplane.service';
import { HttpClientModule } from '@angular/common/http';
import { MyDatePickerModule } from 'mydatepicker';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ListAirplaneComponent } from './components/list-airplane/list-airplane.component';
import { RouterModule } from '@angular/router';
import { EditAirplaneComponent } from './components/edit-airplane/edit-airplane.component';
import { SeoService } from '../../core/services/seo.service';

@NgModule({
  declarations: [AddAirplaneComponent, ListAirplaneComponent, EditAirplaneComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    MyDatePickerModule,
    BrowserAnimationsModule,
    RouterModule
  ],
  providers: [
    Title,
    SeoService,
    AirplaneService
  ],
  exports: [AddAirplaneComponent, ListAirplaneComponent, EditAirplaneComponent]
})
export class AirplaneModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { RouterModule } from '@angular/router';
import { CardsComponent } from './components/cards/cards.component';
import { FooterComponent } from './components/footer/footer.component';

@NgModule({
  declarations: [NavBarComponent, CardsComponent, FooterComponent],
  imports: [
    RouterModule,
    CommonModule
  ],
  exports: [NavBarComponent, CardsComponent, FooterComponent], 
})
export class SharedModule { }

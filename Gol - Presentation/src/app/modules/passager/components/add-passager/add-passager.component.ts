import { Component, OnInit, ViewChildren, ElementRef, AfterViewInit } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, FormControl, FormArray, Validators, FormControlName } from '@angular/forms';
import { PassagerService } from '../../services/passager.service';
import { Passager } from '../../models/passager';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DatePipe } from '@angular/common';
import { AirplaneService } from '../../../airplane/services/airplane.service';
import { Airplane } from '../../../../modules/airplane/models/airplane';

@Component({
  selector: 'gol-add-passager',
  templateUrl: './add-passager.component.html',
  styleUrls: ['./add-passager.component.scss']
})
export class AddPassagerComponent implements OnInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  public errors: any[] = [];
  public passager: Passager;
  public airplanes: Airplane[] = [];
  public idPassager;

  constructor(private passagerService: PassagerService,
              private airplaneService: AirplaneService,
              private toastr: ToastrService,
              private router: Router) {

    this.passager = new Passager();
  }


  ngOnInit() {
    // Erro de versão do FormGroup - necessário refatoração
    this.passager.name = '';
    this.passager.type = '';
    this.passager.seat = '';
    this.passager.idAirplane = '';
    this.getAirplanes();

  }
  
  getAirplanes() {
    this.airplaneService.obterTodos()
      .subscribe(
        result => {this.airplanes = result; },
        fail => {this.onError(fail)}
      );
  }

  adicionarPassager(form: FormGroup) {
    if (form.valid) {
      this.passagerService.registrarPassager(this.passager)
        .subscribe(
          result => { this.onSaveComplete(); },
          fail => { this.onError(fail); }
        );
    } else {
      this.toastr.error('Verifique os campos');
    }
  }

  onError(fail) {
    this.toastr.error('Ocorreu um erro no processamento', 'Ops! :(');
    this.errors = fail.error.errors;
  }

  onSaveComplete() {
    this.errors = [];
    this.toastr.success('Passager Registrado com Sucesso!', 'Oba :D', { timeOut: 2000 });

    this.passager = new Passager();

    setTimeout(() => this.router.navigate(['/passagers']), 2000);

  }

}

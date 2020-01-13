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
  selector: 'gol-edit-passager',
  templateUrl: './edit-passager.component.html',
  styleUrls: ['./edit-passager.component.scss']
})
export class EditPassagerComponent implements OnInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  public errors: any[] = [];
  public passager: Passager;
  public airplanes: Airplane[] = [];
  public idPassager;

  constructor(private passagerService: PassagerService,
              private airplaneService: AirplaneService,
              private toastr: ToastrService,
              private router: Router,
              private route: ActivatedRoute) {


    this.passager = new Passager();
  }


  ngOnInit() {

    this.airplaneService.obterTodos()
    .subscribe(
      result => {this.airplanes = result; this.getPassager() },
      fail => {this.onError(fail)}
    );
  }

  getPassager() {
    this.route.params.subscribe(params => {
      this.passagerService.obterPassager(params.id)
        .subscribe(passager => {
          this.passager = passager;
        },
          error => this.errors);
    });
  }

  editarPassager(form: FormGroup) {
    if (form.valid) {
      this.passagerService.atualizarPassager(this.passager)
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
    this.toastr.success('Passager Editado com Sucesso!', 'Oba :D', { timeOut: 2000 });

    this.passager = new Passager();

    setTimeout(() => this.router.navigate(['/passagers']), 2000);

  }

}

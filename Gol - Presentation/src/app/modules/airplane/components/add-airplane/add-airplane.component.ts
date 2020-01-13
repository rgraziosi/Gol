import { Component, OnInit, ViewChildren, ElementRef, AfterViewInit } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, FormControl, FormArray, Validators, FormControlName } from '@angular/forms';
import { AirplaneService } from '../../services/airplane.service';
import { Airplane } from '../../models/airplane';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'gol-add-airplane',
  templateUrl: './add-airplane.component.html',
  styleUrls: ['./add-airplane.component.scss']
})
export class AddAirplaneComponent implements OnInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  public errors: any[] = [];
  public airplane: Airplane;
  public idAirplane;

  constructor(private airplaneService: AirplaneService,
              private toastr: ToastrService,
              private router: Router) {

    this.airplane = new Airplane();
  }


  ngOnInit() {
    // Erro de versão do FormGroup - necessário refatoração
    this.airplane.name = '';
    this.airplane.type = '';
  }

  adicionarAirplane(form: FormGroup) {
    if (form.valid) {
      this.airplaneService.registrarAirplane(this.airplane)
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
    this.toastr.success('Airplane Registrado com Sucesso!', 'Oba :D', { timeOut: 2000 });

    this.airplane = new Airplane();

    setTimeout(() => this.router.navigate(['/airplanes']), 2000);

  }

}

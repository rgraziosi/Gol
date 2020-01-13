import { Component, OnInit, ViewChildren, ElementRef, AfterViewInit } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, FormControl, FormArray, Validators, FormControlName } from '@angular/forms';
import { AirplaneService } from '../../services/airplane.service';
import { Airplane } from '../../models/airplane';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'gol-edit-airplane',
  templateUrl: './edit-airplane.component.html',
  styleUrls: ['./edit-airplane.component.scss']
})
export class EditAirplaneComponent implements OnInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  public errors: any[] = [];
  public airplane: Airplane;
  public idAirplane;

  constructor(private airplaneService: AirplaneService,
              private toastr: ToastrService,
              private router: Router,
              private route: ActivatedRoute) {


    this.airplane = new Airplane();
  }


  ngOnInit() {
    this.route.params.subscribe(params => {
      this.airplaneService.obterAirplane(params.id)
        .subscribe(airplane => {
          this.airplane = airplane;
        },
          error => this.errors);
    });

  }

  editarAirplane(form: FormGroup) {
    if (form.valid) {
      this.airplaneService.atualizarAirplane(this.airplane)
        .subscribe(
          result => { this.onSaveComplete(); },
          fail => { this.onError(fail); }
        );
    }else {
      this.toastr.error('Verifique os campos');
    }
  }

  onError(fail) {
    this.toastr.error('Ocorreu um erro no processamento', 'Ops! :(');
    this.errors = fail.error.errors;
  }

  onSaveComplete() {
    this.errors = [];
    this.toastr.success('Airplane Editado com Sucesso!', 'Oba :D', { timeOut: 2000 });

    this.airplane = new Airplane();

    setTimeout(() => this.router.navigate(['/airplanes']), 2000);

  }

}

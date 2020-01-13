import { Component, OnInit } from '@angular/core';
import { Passager } from '../../models/passager';
import { PassagerService } from '../../services/passager.service';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';
import { AirplaneService } from '../../../airplane/services/airplane.service';
import { Airplane } from '../../../../modules/airplane/models/airplane';

@Component({
  selector: 'gol-flight-passager',
  templateUrl: './flight-passager.component.html',
  styleUrls: ['./flight-passager.component.scss'],
})
export class FlightPassagerComponent implements OnInit {

  public passagers: Passager[];
  public airplane: Airplane = new Airplane();
  errorMessage: string;
  errors: any[];

  constructor(private passagerService: PassagerService, 
              private toastr: ToastrService,
              private airplaneService: AirplaneService,
              private router: Router,
              private route: ActivatedRoute ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.getAirplane(params.idAirplane);

      this.passagerService.obterPassagersByAirplane(params.idAirplane)
      .subscribe(
        passagers => {
          this.passagers = passagers;
        },
        error => this.errorMessage);

    });

  }

  getAirplane(idAirplane: string){
    this.airplaneService.obterAirplane(idAirplane).subscribe(
      result => this.airplane = result,
      fail => this.errorMessage
    );
  }

  excluirPassager(id) {
    this.passagerService.excluirPassager(id)
      .subscribe(
        result => { this.onExcludeComplete(id); },
        fail => { this.onError(fail); }
      );
  }

  onError(fail) {
    this.toastr.error('Ocorreu um erro no processamento', 'Ops! :(');
    this.errors = fail.error.errors;
  }

  onExcludeComplete(idExclude) {
    this.errors = [];
    this.passagers.forEach((element, index) => {
      if (element.id == idExclude) { this.passagers.splice(index, 1); }
    });
    this.toastr.success('Passager Excluido com Sucesso! o alert de confirmação vem na proxima versão', 'Eita', { timeOut: 3000 });
  }

}

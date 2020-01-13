import { Component, OnInit } from '@angular/core';
import { Passager } from '../../models/passager';
import { PassagerService } from '../../services/passager.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'gol-list-passager',
  templateUrl: './list-passager.component.html',
  styleUrls: ['./list-passager.component.scss'],
})
export class ListPassagerComponent implements OnInit {

  public passagers: Passager[];
  errorMessage: string;
  errors: any[];

  constructor(private passagerService: PassagerService, private toastr: ToastrService, ) { }

  ngOnInit() {
    this.passagerService.obterTodos()
      .subscribe(passagers => this.passagers = passagers,
        error => this.errorMessage);
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

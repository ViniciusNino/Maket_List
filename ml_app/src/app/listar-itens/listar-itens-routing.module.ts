import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ListarItensPage } from './listar-itens.page';
import { ModalSolicitacaoComponent } from '../modal-solicitacao/modal-solicitacao.component';

const routes: Routes = [
  {
    path: '',
    component: ListarItensPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ListarItensPageRoutingModule {}

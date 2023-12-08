import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastrarUsuarioComponent } from './pages/usuario/cadastrar-usuario/cadastrar-usuario.component';
import { CadastrarImcComponent } from './pages/imc/cadastrar-imc/cadastrar-imc.component';
import { ListarImcComponent } from './pages/imc/listar-imc/listar-imc.component';

const routes: Routes = [
  {
    path: "pages/usuario/cadastrar-usuario",
    component: CadastrarUsuarioComponent
  },
  {
    path: "pages/imc/cadastrar-imc",
    component: CadastrarImcComponent
  },
  {
    path: "",
    component:ListarImcComponent
  },
  {
    path: "pages/imc/listar-imc",
    component:ListarImcComponent
  },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { DepartamentoService } from './departamento.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Departamento } from './../models/Departamento';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-departamentos',
  templateUrl: './departamentos.component.html',
  styleUrls: ['./departamentos.component.css']
})

export class DepartamentosComponent implements OnInit {

  public title = 'Departamentos';

  public departamentoForm: FormGroup;
  public departSelecionado: Departamento;

  public idSelecionado: Number;

  public modalRef?: BsModalRef;

  public departamentos: Departamento[];

  public sigla: string = 'Indisponível';


  selecionaDepart(departamento: Departamento) {
    this.departSelecionado = departamento;
    this.departamentoForm.patchValue(departamento);
  }
  selecionaId(departamento: Departamento) {
    this.idSelecionado = departamento.id;
  }

  carregarDepartamentos() {
    this.departamentoService.getAll().subscribe(
      (departamentos: Departamento[]) => {
        this.departamentos = departamentos;
      },
      (erro: any) => {
        console.error(erro)
      }
    );
  }

  criarDepartamento(departamento: Departamento) {
    this.departamentoService.post(departamento).subscribe(
      (retorno) => {
        console.log(retorno);
        this.carregarDepartamentos();
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  salvarDepartamento(departamento: Departamento) {
    this.departamentoService.put(departamento.id, departamento).subscribe(
      (retorno) => {
        console.log(retorno);
        this.carregarDepartamentos();
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  deletarDepartamento(id: number) {
    this.departamentoService.delete(id).subscribe(
      (model: any) => {
        console.log(model);
        this.carregarDepartamentos();
      },
      (erro: any) => {
        console.error(erro);
      }
    );
  }

  novoDepartamento() {
    this.departSelecionado = new Departamento();
    this.departamentoForm.patchValue(this.departSelecionado);
  }

  criaForm() {
    this.departamentoForm = this.fb.group({
      nome: ['', Validators.required],
      sigla: [this.sigla],
      id: ['']
    });
  }

  editarSubmit() {
    this.salvarDepartamento(this.departamentoForm.value);
  }
  criarSubmit() {
    this.criarDepartamento(this.departamentoForm.value);
  }
  
  redirecionar() {
    this.router.navigate([`/funcionarios`])
  }

  departEIdRedireciona(departamento: Departamento) {
    this.selecionaDepart(departamento);
    this.selecionaId(departamento)
    this.redirecionar();
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  novoDepartAbreModal(template: TemplateRef<any>) {
    this.novoDepartamento();
    this.openModal(template)
  }

  selecionaDepartAbreModal(departamento: Departamento, template: TemplateRef<any>) {
    this.selecionaDepart(departamento);
    this.openModal(template);
  }

  constructor(private router: Router,
    private modalService: BsModalService,
    private departamentoService: DepartamentoService,
    private fb: FormBuilder) {
    this.criaForm();
  }

  ngOnInit() {
    this.carregarDepartamentos();
    1
  }
}

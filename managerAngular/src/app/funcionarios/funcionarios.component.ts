import { FuncionarioService } from './funcionario.service';
import { Funcionario } from './../models/Funcionario';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-funcionarios',
  templateUrl: './funcionarios.component.html',
  styleUrls: ['./funcionarios.component.css']
})


export class FuncionariosComponent implements OnInit {

  public title = 'Funcionarios';

  public modalRef?: BsModalRef;

  public funcionarioForm: FormGroup;
  public funcioSelecionado: Funcionario;

  public idDepartamento: number = 4;


  public foto: string = '../assets/img/default.png'
  fileToUpload: File = null;

  public funcionarios: Funcionario[];

  selecionaFuncio(funcionario: Funcionario) {
    this.funcioSelecionado = funcionario;
    this.funcionarioForm.patchValue(funcionario);
  }

  carregarFuncionarios() {
    this.funcionarioService.getByIdDepartamento(this.idDepartamento).subscribe(
      (funcionarios: Funcionario[]) => {
        this.funcionarios = funcionarios;
      },
      (erro: any) => {
        console.error(erro);
      }
    );
  }

  criarFuncionario(funcionario: Funcionario) {
    this.funcionarioService.postByIdDepartamento(funcionario.idDepartamento, funcionario).subscribe(
      (retorno) => {
        console.log(retorno);
        this.carregarFuncionarios();
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  salvarFuncionario(funcionario: Funcionario) {
    this.funcionarioService.put(funcionario.id, funcionario).subscribe(
      (retorno) => {
        console.log(retorno);
        this.carregarFuncionarios();
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  deletarFuncionario(id: number) {
    this.funcionarioService.delete(id).subscribe(
      (model: any) => {
        console.log(model);
        this.carregarFuncionarios();
      },
      (erro: any) => {
        console.error(erro);
      }
    );
  }

  novoFuncionario() {
    this.funcioSelecionado = new Funcionario();
    this.funcionarioForm.patchValue(this.funcioSelecionado);
  }

  criaForm() {
    this.funcionarioForm = this.fb.group({
      id: ['',],
      foto: ['',],
      nome: ['', Validators.required],
      rg: ['', Validators.required],
      idDepartamento: [this.idDepartamento, Validators.required]
    });
  }

  editarSubmit() {
    this.salvarFuncionario(this.funcionarioForm.value)
  }
  criarSubmit() {
    this.criarFuncionario(this.funcionarioForm.value)
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  novoFuncioAbreModal(template: TemplateRef<any>) {
    this.novoFuncionario();
    this.openModal(template)
  }

  selecionaFuncioAbreModal(funcionario: Funcionario, template: TemplateRef<any>) {
    this.selecionaFuncio(funcionario);
    this.openModal(template)
  }



  constructor(private modalService: BsModalService,
    private funcionarioService: FuncionarioService,
    private fb: FormBuilder) {

    this.criaForm()
  }

  ngOnInit() {
    this.carregarFuncionarios();
  }
}

import { Funcionario } from './../models/Funcionario';
import { environment } from './../../environments/environment';
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FuncionarioService {

  baseUrl = `${environment.baseUrl}/funcionario`;

  constructor(private http: HttpClient) {  }

  getByIdDepartamento(IdDepartamento: number): Observable<Funcionario[]> {
    return this.http.get<Funcionario[]>(`${this.baseUrl}/ByDepartamento/${IdDepartamento}`);
  }
  postByIdDepartamento(IdDepartamento: number, funcionario: Funcionario) {
    return this.http.post(`${this.baseUrl}/ByDepartamento/${IdDepartamento}`, funcionario);
  }
  put(id: number, funcionario: Funcionario) {
    return this.http.put(`${this.baseUrl}/${id}`, funcionario);
  }
  delete(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
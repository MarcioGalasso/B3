import { Component, ViewChild } from '@angular/core';
import {CdbCalulado} from './interfaces/cdbCalulado';
import {Cdb} from './interfaces/cdb';
import { CdbService } from './services/cdb.service';
import { MatTableDataSource } from '@angular/material/table';
import {
  MatSnackBar,
  MatSnackBarHorizontalPosition,
  MatSnackBarVerticalPosition,
} from '@angular/material/snack-bar';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})


export class AppComponent {
  title = 'Prova B3';
  
  displayedColumns: string[] = ['valor', 'meses', 'imposto', 'liquido', 'bruto'];
  dataSource = new MatTableDataSource<CdbCalulado>([]);  
  cdb : Cdb =  {valor:0,meses:0};
  
  horizontalPosition: MatSnackBarHorizontalPosition = 'start';
  verticalPosition: MatSnackBarVerticalPosition = 'bottom';

   

  constructor(private cdbService : CdbService,private _snackBar: MatSnackBar) {

   
  }

  simularRendimento() 
  {
    
     this.cdbService.calcularAsync(this.cdb)
     .subscribe(
      {
        next: (response) => 
          { 

            this.dataSource.data.push(response);
            this.dataSource.data = [...this.dataSource.data];
            this.cdb.meses=0;
            this.cdb.valor=0;
            
            this._snackBar.open("Simulação feita com sucesso", 'Ocultar', {
              horizontalPosition: this.horizontalPosition,
              verticalPosition: this.verticalPosition,
              duration: 2 * 1000
            });
          },
        error: (e) =>{ 
          if(e.status== 400){
          this._snackBar.open(e.error, 'Ocultar', {
            horizontalPosition: this.horizontalPosition,
            verticalPosition: this.verticalPosition,
            duration: 4 * 1000
          })}
          else{
            this._snackBar.open("Ocorreu problema, tente mais tarde", 'Ocultar', {
              horizontalPosition: this.horizontalPosition,
              verticalPosition: this.verticalPosition,
              duration: 4 * 1000
            });
          }
          console.error(e)
        }
      
       } );
    
  }
  
}


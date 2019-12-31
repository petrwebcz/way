import { Component } from '@angular/core';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})

export class AppComponent {
    title = 'WAY - vytvoř setkání a pošli svou polohu odkazem';

    constructor() { }

    //openConfirmationDialog() {
    //    this.dialogRef = this.dialog.open(ConfirmationDialog, {
    //        disableClose: false
    //    });
    //    this.dialogRef.componentInstance.confirmMessage = "Are you sure you want to delete?"

    //    this.dialogRef.afterClosed().subscribe(result => {
    //        if (result) {
    //        }
    //        this.dialogRef = null;
    //    });
    //}
}

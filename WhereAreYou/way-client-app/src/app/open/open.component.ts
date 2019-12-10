import { Component, OnInit } from '@angular/core';
import { Routes, Router, RouterModule } from '@angular/router';
import { StateService } from 'src/app/state.service';

@Component({
    selector: 'app-open',
    templateUrl: './open.component.html',
    styleUrls: ['./open.component.css']
})
export class OpenComponent implements OnInit {
    message: string = "Vaše setkání se připravuje.";
    constructor(private state: StateService, private router: Router) { }

    async ngOnInit() {
        try {
            //await this.state.openRoom();
            await delay(3000);
            this.router.navigate(['room']);
        }
        catch (e) {
            this.message = "Nepodařio se otevřít setkání. Zkuste to prosím znovu, případně si vytvořte nové.";
            console.log(e);
        }

        function delay(ms: number) {
            return new Promise(resolve => setTimeout(resolve, ms));
        }
    }
}

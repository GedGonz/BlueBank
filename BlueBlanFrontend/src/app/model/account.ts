export class account {
    accountid: string;
    number: string;
    valueinit: string;
    valuecurrent: string;
    type: number;
    clientid: string;
    accountmoves:[{
        accountmoveid:string;
        value: string;
        typemove:number;
        datemove:string;
    }]
}
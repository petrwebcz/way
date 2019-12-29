//// ..\..\Core\Entity\AdvertPosition.cs
//    export class AdvertPosition {
//        user: User;
//        location: Location;
//    }

//    // ..\..\Core\Entity\Location.cs
//    export class Location {
//        latitude: number;
//        longitude: number;
//    }

//    // ..\..\Core\Entity\Position.cs
//    export class Position {
//        user: User;
//        location: Location;

//        constructor() { }
//    }

//    // ..\..\Core\Entity\Meet.cs
//    export class Meet {

//        id: string;
//        name: string;
//        created: string;
//        lastUpdated: string;
//        positions: Position[];
//        inviteUrl: string;
//        inviteHash: string;
//        centerPoint: Location;

//        public constructor(init?: Partial<Meet>) {
//            Object.assign(this, init);
//        }
//    }

//    // ..\..\Core\Entity\User.cs 
//    export class User {
//        id: string;
//        nickname: string;
//        meetInviteHash: string;

//    }

//    // ..\..\Core\Requests\CreateMeet.cs
//    export class CreateMeet {
//        name: string;
//    }

//    // ..\..\Core\Requests\EnterTheMeet.cs
//    export class EnterTheMeet {
//        nickname: string;
//        inviteHash: string;
//        inviteUrl: string;

//        public constructor(init?: Partial<EnterTheMeet>) {
//            Object.assign(this, init);
//        }
//    }

//    // ..\..\Core\Requests\UpdatePosition.cs
//    export class UpdatePosition {
//        location: Location;

//        public constructor(init?: Partial<UpdatePosition>) {
//            Object.assign(this, init);
//        }
//    }

//    // ..\..\Core\Responses\CreatedMeet.cs
//    export class CreatedMeet {
//        inviteUrl: string;
//        inviteHash: string;
//        name: string;

//        public constructor(init?: Partial<CreatedMeet>) {
//            Object.assign(this, init);
//        }
//    }

//    // ..\..\Core\Responses\Token.cs
//    export class Token {
//        jwt: string;

//        public constructor(init?: Partial<>) {
//            Object.assign(this, init);
//        }
//    }

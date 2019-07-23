namespace CSharpInterop.Domain

open System

type Customer(firstName: string, lastName: string, birthdate: DateTime) =
    // perform the calculation only once. Otherwise it will get created as a property with a function getter
    let code = (firstName + lastName + DateTime.Now.ToLongTimeString()).ToUpper()
    member x.FirstName = firstName
    member x.LastName = lastName
    member x.Code = code
    member x.Birthdate = birthdate

type CustomerRecord = { FirstName: string; LastName: string; Birthdate: DateTime } with
    member x.Code = (x.FirstName + x.LastName + DateTime.Now.ToLongTimeString()).ToUpper()

type CustomerRecord2 = { FirstName: string; LastName: string; Birthdate: DateTime; Code: string } with
    static member Create firstName lastName birthdate = {
        FirstName = firstName
        LastName = lastName
        Birthdate = birthdate
        Code = (firstName + lastName + DateTime.Now.ToLongTimeString()).ToUpper()
    }

namespace ReactiveUINavigate

open System

open ReactiveUI

type MainViewModel() as this =
    inherit ViewModelBase()

    let mutable textProperty = String.Empty
    let mutable navigateCommand = Unchecked.defaultof<ReactiveCommand<Reactive.Unit, Reactive.Unit>>

    do
        navigateCommand <- ReactiveCommand.Create(fun () -> this.HostScreen.Router.Navigate.Execute(new SecondViewModel()).Subscribe() |> ignore)

    member __.TextProperty
        with get() =
            textProperty
        and set(value) =
            this.RaiseAndSetIfChanged(&textProperty, value) |> ignore

    member __.NavigateCommand
        with get() =
            navigateCommand

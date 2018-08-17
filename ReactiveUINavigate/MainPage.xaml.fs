namespace ReactiveUINavigate

open Xamarin.Forms
open Xamarin.Forms.Xaml

open ReactiveUI

open ExpressionConversion

type MainPage() =
    inherit ContentPageBase<MainViewModel>()

    let _ = base.LoadFromXaml(typeof<MainPage>)

    let mutable textLabel = base.FindByName<Label>("TextLabel")
    let mutable navigateButton = base.FindByName<Button>("NavigateButton")

    override this.OnAppearing() =
        base.OnAppearing()

        NavigationPage.SetHasNavigationBar(this, false)

        this.Bind(this.ViewModel, toLinq <@ fun vm -> vm.TextProperty @>, toLinq <@ fun v -> (v.TextLabel: Label).Text @>) |> this.PageDisposables.Add
        this.BindCommand(this.ViewModel, toLinq <@ fun vm -> vm.NavigateCommand @>, toLinq <@ fun v -> v.NavigateButton @>) |> this.PageDisposables.Add

        this.ViewModel.TextProperty <- "Hello ReactiveUI World!"

    member val TextLabel = textLabel with get, set
    member val NavigateButton = navigateButton with get, set

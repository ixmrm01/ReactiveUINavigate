namespace ReactiveUINavigate

open System
open System.Linq.Expressions

open Microsoft.FSharp.Linq.RuntimeHelpers
open Microsoft.FSharp.Quotations

open Splat

module ExpressionConversion =
    let toLambda (exp: Expr) =
        let linq = LeafExpressionConverter.QuotationToExpression exp :?> MethodCallExpression
        linq.Arguments.[0] :?> LambdaExpression

    let toLinq (exp: Expr<'a -> 'b>) =
        let lambda = toLambda exp
        Expression.Lambda<Func<'a, 'b>>(lambda.Body, lambda.Parameters)

module LocatorDefaults =
    let LocateIfNone(arg: 'a option) =
        match arg with
        | None -> Locator.Current.GetService<'a>()
        | Some a -> a

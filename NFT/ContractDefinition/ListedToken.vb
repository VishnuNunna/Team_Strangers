Imports System
Imports System.Threading.Tasks
Imports System.Collections.Generic
Imports System.Numerics
Imports Nethereum.Hex.HexTypes
Imports Nethereum.ABI.FunctionEncoding.Attributes
Namespace NFTMarketplaceTutorial.Contracts.NFTMarketplace.ContractDefinition

    Public Partial Class ListedToken
        Inherits ListedTokenBase
    End Class

    Public Class ListedTokenBase
        
        <[Parameter]("uint256", "tokenId", 1)>
        Public Overridable Property [TokenId] As BigInteger
        <[Parameter]("address", "owner", 2)>
        Public Overridable Property [Owner] As String
        <[Parameter]("address", "seller", 3)>
        Public Overridable Property [Seller] As String
        <[Parameter]("uint256", "price", 4)>
        Public Overridable Property [Price] As BigInteger
        <[Parameter]("bool", "currentlyListed", 5)>
        Public Overridable Property [CurrentlyListed] As Boolean
    
    End Class

End Namespace

Imports System
Imports System.Threading.Tasks
Imports System.Collections.Generic
Imports System.Numerics
Imports Nethereum.Hex.HexTypes
Imports Nethereum.ABI.FunctionEncoding.Attributes
Imports Nethereum.Web3
Imports Nethereum.RPC.Eth.DTOs
Imports Nethereum.Contracts.CQS
Imports Nethereum.Contracts.ContractHandlers
Imports Nethereum.Contracts
Imports System.Threading
Imports NFTMarketplaceTutorial.Contracts.NFTMarketplace.ContractDefinition
Namespace NFTMarketplaceTutorial.Contracts.NFTMarketplace


    Public Partial Class NFTMarketplaceService
    
    
        Public Shared Function DeployContractAndWaitForReceiptAsync(ByVal web3 As Nethereum.Web3.Web3, ByVal nFTMarketplaceDeployment As NFTMarketplaceDeployment, ByVal Optional cancellationTokenSource As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return web3.Eth.GetContractDeploymentHandler(Of NFTMarketplaceDeployment)().SendRequestAndWaitForReceiptAsync(nFTMarketplaceDeployment, cancellationTokenSource)
        
        End Function
         Public Shared Function DeployContractAsync(ByVal web3 As Nethereum.Web3.Web3, ByVal nFTMarketplaceDeployment As NFTMarketplaceDeployment) As Task(Of String)
        
            Return web3.Eth.GetContractDeploymentHandler(Of NFTMarketplaceDeployment)().SendRequestAsync(nFTMarketplaceDeployment)
        
        End Function
        Public Shared Async Function DeployContractAndGetServiceAsync(ByVal web3 As Nethereum.Web3.Web3, ByVal nFTMarketplaceDeployment As NFTMarketplaceDeployment, ByVal Optional cancellationTokenSource As CancellationTokenSource = Nothing) As Task(Of NFTMarketplaceService)
        
            Dim receipt = Await DeployContractAndWaitForReceiptAsync(web3, nFTMarketplaceDeployment, cancellationTokenSource)
            Return New NFTMarketplaceService(web3, receipt.ContractAddress)
        
        End Function
    
        Protected Property Web3 As Nethereum.Web3.Web3
        
        Public Property ContractHandler As ContractHandler
        
        Public Sub New(ByVal web3 As Nethereum.Web3.Web3, ByVal contractAddress As String)
            Web3 = web3
            ContractHandler = web3.Eth.GetContractHandler(contractAddress)
        End Sub
    
        Public Function ApproveRequestAsync(ByVal approveFunction As ApproveFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of ApproveFunction)(approveFunction)
        
        End Function

        Public Function ApproveRequestAndWaitForReceiptAsync(ByVal approveFunction As ApproveFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of ApproveFunction)(approveFunction, cancellationToken)
        
        End Function

        
        Public Function ApproveRequestAsync(ByVal [to] As String, ByVal [tokenId] As BigInteger) As Task(Of String)
        
            Dim approveFunction = New ApproveFunction()
                approveFunction.To = [to]
                approveFunction.TokenId = [tokenId]
            
            Return ContractHandler.SendRequestAsync(Of ApproveFunction)(approveFunction)
        
        End Function

        
        Public Function ApproveRequestAndWaitForReceiptAsync(ByVal [to] As String, ByVal [tokenId] As BigInteger, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim approveFunction = New ApproveFunction()
                approveFunction.To = [to]
                approveFunction.TokenId = [tokenId]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of ApproveFunction)(approveFunction, cancellationToken)
        
        End Function
        Public Function BalanceOfQueryAsync(ByVal balanceOfFunction As BalanceOfFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of BigInteger)
        
            Return ContractHandler.QueryAsync(Of BalanceOfFunction, BigInteger)(balanceOfFunction, blockParameter)
        
        End Function

        
        Public Function BalanceOfQueryAsync(ByVal [owner] As String, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of BigInteger)
        
            Dim balanceOfFunction = New BalanceOfFunction()
                balanceOfFunction.Owner = [owner]
            
            Return ContractHandler.QueryAsync(Of BalanceOfFunction, BigInteger)(balanceOfFunction, blockParameter)
        
        End Function


        Public Function CreateTokenRequestAsync(ByVal createTokenFunction As CreateTokenFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of CreateTokenFunction)(createTokenFunction)
        
        End Function

        Public Function CreateTokenRequestAndWaitForReceiptAsync(ByVal createTokenFunction As CreateTokenFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of CreateTokenFunction)(createTokenFunction, cancellationToken)
        
        End Function

        
        Public Function CreateTokenRequestAsync(ByVal [tokenURI] As String, ByVal [price] As BigInteger) As Task(Of String)
        
            Dim createTokenFunction = New CreateTokenFunction()
                createTokenFunction.TokenURI = [tokenURI]
                createTokenFunction.Price = [price]
            
            Return ContractHandler.SendRequestAsync(Of CreateTokenFunction)(createTokenFunction)
        
        End Function

        
        Public Function CreateTokenRequestAndWaitForReceiptAsync(ByVal [tokenURI] As String, ByVal [price] As BigInteger, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim createTokenFunction = New CreateTokenFunction()
                createTokenFunction.TokenURI = [tokenURI]
                createTokenFunction.Price = [price]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of CreateTokenFunction)(createTokenFunction, cancellationToken)
        
        End Function
        Public Function DeadlineQueryAsync(ByVal deadlineFunction As DeadlineFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of BigInteger)
        
            Return ContractHandler.QueryAsync(Of DeadlineFunction, BigInteger)(deadlineFunction, blockParameter)
        
        End Function

        
        Public Function DeadlineQueryAsync(ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of BigInteger)
        
            return ContractHandler.QueryAsync(Of DeadlineFunction, BigInteger)(Nothing, blockParameter)
        
        End Function



        Public Function ExecuteSaleRequestAsync(ByVal executeSaleFunction As ExecuteSaleFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of ExecuteSaleFunction)(executeSaleFunction)
        
        End Function

        Public Function ExecuteSaleRequestAndWaitForReceiptAsync(ByVal executeSaleFunction As ExecuteSaleFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of ExecuteSaleFunction)(executeSaleFunction, cancellationToken)
        
        End Function

        
        Public Function ExecuteSaleRequestAsync(ByVal [tokenId] As BigInteger, ByVal [numberOfDays] As BigInteger) As Task(Of String)
        
            Dim executeSaleFunction = New ExecuteSaleFunction()
                executeSaleFunction.TokenId = [tokenId]
                executeSaleFunction.NumberOfDays = [numberOfDays]
            
            Return ContractHandler.SendRequestAsync(Of ExecuteSaleFunction)(executeSaleFunction)
        
        End Function

        
        Public Function ExecuteSaleRequestAndWaitForReceiptAsync(ByVal [tokenId] As BigInteger, ByVal [numberOfDays] As BigInteger, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim executeSaleFunction = New ExecuteSaleFunction()
                executeSaleFunction.TokenId = [tokenId]
                executeSaleFunction.NumberOfDays = [numberOfDays]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of ExecuteSaleFunction)(executeSaleFunction, cancellationToken)
        
        End Function
        Public Function GetAllNFTsQueryAsync(ByVal getAllNFTsFunction As GetAllNFTsFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of GetAllNFTsOutputDTO)
        
            Return ContractHandler.QueryDeserializingToObjectAsync(Of GetAllNFTsFunction, GetAllNFTsOutputDTO)(getAllNFTsFunction, blockParameter)
        
        End Function

        
        Public Function GetAllNFTsQueryAsync(ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of GetAllNFTsOutputDTO)
        
            return ContractHandler.QueryDeserializingToObjectAsync(Of GetAllNFTsFunction, GetAllNFTsOutputDTO)(Nothing, blockParameter)
        
        End Function



        Public Function GetApprovedQueryAsync(ByVal getApprovedFunction As GetApprovedFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Return ContractHandler.QueryAsync(Of GetApprovedFunction, String)(getApprovedFunction, blockParameter)
        
        End Function

        
        Public Function GetApprovedQueryAsync(ByVal [tokenId] As BigInteger, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Dim getApprovedFunction = New GetApprovedFunction()
                getApprovedFunction.TokenId = [tokenId]
            
            Return ContractHandler.QueryAsync(Of GetApprovedFunction, String)(getApprovedFunction, blockParameter)
        
        End Function


        Public Function GetCurrentTokenQueryAsync(ByVal getCurrentTokenFunction As GetCurrentTokenFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of BigInteger)
        
            Return ContractHandler.QueryAsync(Of GetCurrentTokenFunction, BigInteger)(getCurrentTokenFunction, blockParameter)
        
        End Function

        
        Public Function GetCurrentTokenQueryAsync(ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of BigInteger)
        
            return ContractHandler.QueryAsync(Of GetCurrentTokenFunction, BigInteger)(Nothing, blockParameter)
        
        End Function



        Public Function GetLatestIdToListedTokenQueryAsync(ByVal getLatestIdToListedTokenFunction As GetLatestIdToListedTokenFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of GetLatestIdToListedTokenOutputDTO)
        
            Return ContractHandler.QueryDeserializingToObjectAsync(Of GetLatestIdToListedTokenFunction, GetLatestIdToListedTokenOutputDTO)(getLatestIdToListedTokenFunction, blockParameter)
        
        End Function

        
        Public Function GetLatestIdToListedTokenQueryAsync(ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of GetLatestIdToListedTokenOutputDTO)
        
            return ContractHandler.QueryDeserializingToObjectAsync(Of GetLatestIdToListedTokenFunction, GetLatestIdToListedTokenOutputDTO)(Nothing, blockParameter)
        
        End Function



        Public Function GetListPriceQueryAsync(ByVal getListPriceFunction As GetListPriceFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of BigInteger)
        
            Return ContractHandler.QueryAsync(Of GetListPriceFunction, BigInteger)(getListPriceFunction, blockParameter)
        
        End Function

        
        Public Function GetListPriceQueryAsync(ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of BigInteger)
        
            return ContractHandler.QueryAsync(Of GetListPriceFunction, BigInteger)(Nothing, blockParameter)
        
        End Function



        Public Function GetListedTokenForIdQueryAsync(ByVal getListedTokenForIdFunction As GetListedTokenForIdFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of GetListedTokenForIdOutputDTO)
        
            Return ContractHandler.QueryDeserializingToObjectAsync(Of GetListedTokenForIdFunction, GetListedTokenForIdOutputDTO)(getListedTokenForIdFunction, blockParameter)
        
        End Function

        
        Public Function GetListedTokenForIdQueryAsync(ByVal [tokenId] As BigInteger, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of GetListedTokenForIdOutputDTO)
        
            Dim getListedTokenForIdFunction = New GetListedTokenForIdFunction()
                getListedTokenForIdFunction.TokenId = [tokenId]
            
            Return ContractHandler.QueryDeserializingToObjectAsync(Of GetListedTokenForIdFunction, GetListedTokenForIdOutputDTO)(getListedTokenForIdFunction, blockParameter)
        
        End Function


        Public Function GetMyNFTsQueryAsync(ByVal getMyNFTsFunction As GetMyNFTsFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of GetMyNFTsOutputDTO)
        
            Return ContractHandler.QueryDeserializingToObjectAsync(Of GetMyNFTsFunction, GetMyNFTsOutputDTO)(getMyNFTsFunction, blockParameter)
        
        End Function

        
        Public Function GetMyNFTsQueryAsync(ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of GetMyNFTsOutputDTO)
        
            return ContractHandler.QueryDeserializingToObjectAsync(Of GetMyNFTsFunction, GetMyNFTsOutputDTO)(Nothing, blockParameter)
        
        End Function



        Public Function IsApprovedForAllQueryAsync(ByVal isApprovedForAllFunction As IsApprovedForAllFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of Boolean)
        
            Return ContractHandler.QueryAsync(Of IsApprovedForAllFunction, Boolean)(isApprovedForAllFunction, blockParameter)
        
        End Function

        
        Public Function IsApprovedForAllQueryAsync(ByVal [owner] As String, ByVal [operator] As String, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of Boolean)
        
            Dim isApprovedForAllFunction = New IsApprovedForAllFunction()
                isApprovedForAllFunction.Owner = [owner]
                isApprovedForAllFunction.Operator = [operator]
            
            Return ContractHandler.QueryAsync(Of IsApprovedForAllFunction, Boolean)(isApprovedForAllFunction, blockParameter)
        
        End Function


        Public Function NameQueryAsync(ByVal nameFunction As NameFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Return ContractHandler.QueryAsync(Of NameFunction, String)(nameFunction, blockParameter)
        
        End Function

        
        Public Function NameQueryAsync(ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            return ContractHandler.QueryAsync(Of NameFunction, String)(Nothing, blockParameter)
        
        End Function



        Public Function OwnerOfQueryAsync(ByVal ownerOfFunction As OwnerOfFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Return ContractHandler.QueryAsync(Of OwnerOfFunction, String)(ownerOfFunction, blockParameter)
        
        End Function

        
        Public Function OwnerOfQueryAsync(ByVal [tokenId] As BigInteger, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Dim ownerOfFunction = New OwnerOfFunction()
                ownerOfFunction.TokenId = [tokenId]
            
            Return ContractHandler.QueryAsync(Of OwnerOfFunction, String)(ownerOfFunction, blockParameter)
        
        End Function


        Public Function SafeTransferFromRequestAsync(ByVal safeTransferFromFunction As SafeTransferFromFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of SafeTransferFromFunction)(safeTransferFromFunction)
        
        End Function

        Public Function SafeTransferFromRequestAndWaitForReceiptAsync(ByVal safeTransferFromFunction As SafeTransferFromFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of SafeTransferFromFunction)(safeTransferFromFunction, cancellationToken)
        
        End Function

        
        Public Function SafeTransferFromRequestAsync(ByVal [from] As String, ByVal [to] As String, ByVal [tokenId] As BigInteger) As Task(Of String)
        
            Dim safeTransferFromFunction = New SafeTransferFromFunction()
                safeTransferFromFunction.From = [from]
                safeTransferFromFunction.To = [to]
                safeTransferFromFunction.TokenId = [tokenId]
            
            Return ContractHandler.SendRequestAsync(Of SafeTransferFromFunction)(safeTransferFromFunction)
        
        End Function

        
        Public Function SafeTransferFromRequestAndWaitForReceiptAsync(ByVal [from] As String, ByVal [to] As String, ByVal [tokenId] As BigInteger, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim safeTransferFromFunction = New SafeTransferFromFunction()
                safeTransferFromFunction.From = [from]
                safeTransferFromFunction.To = [to]
                safeTransferFromFunction.TokenId = [tokenId]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of SafeTransferFromFunction)(safeTransferFromFunction, cancellationToken)
        
        End Function
        Public Function SafeTransferFromRequestAsync(ByVal safeTransferFrom1Function As SafeTransferFrom1Function) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of SafeTransferFrom1Function)(safeTransferFrom1Function)
        
        End Function

        Public Function SafeTransferFromRequestAndWaitForReceiptAsync(ByVal safeTransferFrom1Function As SafeTransferFrom1Function, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of SafeTransferFrom1Function)(safeTransferFrom1Function, cancellationToken)
        
        End Function

        
        Public Function SafeTransferFromRequestAsync(ByVal [from] As String, ByVal [to] As String, ByVal [tokenId] As BigInteger, ByVal [data] As Byte()) As Task(Of String)
        
            Dim safeTransferFrom1Function = New SafeTransferFrom1Function()
                safeTransferFrom1Function.From = [from]
                safeTransferFrom1Function.To = [to]
                safeTransferFrom1Function.TokenId = [tokenId]
                safeTransferFrom1Function.Data = [data]
            
            Return ContractHandler.SendRequestAsync(Of SafeTransferFrom1Function)(safeTransferFrom1Function)
        
        End Function

        
        Public Function SafeTransferFromRequestAndWaitForReceiptAsync(ByVal [from] As String, ByVal [to] As String, ByVal [tokenId] As BigInteger, ByVal [data] As Byte(), ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim safeTransferFrom1Function = New SafeTransferFrom1Function()
                safeTransferFrom1Function.From = [from]
                safeTransferFrom1Function.To = [to]
                safeTransferFrom1Function.TokenId = [tokenId]
                safeTransferFrom1Function.Data = [data]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of SafeTransferFrom1Function)(safeTransferFrom1Function, cancellationToken)
        
        End Function
        Public Function SetApprovalForAllRequestAsync(ByVal setApprovalForAllFunction As SetApprovalForAllFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of SetApprovalForAllFunction)(setApprovalForAllFunction)
        
        End Function

        Public Function SetApprovalForAllRequestAndWaitForReceiptAsync(ByVal setApprovalForAllFunction As SetApprovalForAllFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of SetApprovalForAllFunction)(setApprovalForAllFunction, cancellationToken)
        
        End Function

        
        Public Function SetApprovalForAllRequestAsync(ByVal [operator] As String, ByVal [approved] As Boolean) As Task(Of String)
        
            Dim setApprovalForAllFunction = New SetApprovalForAllFunction()
                setApprovalForAllFunction.Operator = [operator]
                setApprovalForAllFunction.Approved = [approved]
            
            Return ContractHandler.SendRequestAsync(Of SetApprovalForAllFunction)(setApprovalForAllFunction)
        
        End Function

        
        Public Function SetApprovalForAllRequestAndWaitForReceiptAsync(ByVal [operator] As String, ByVal [approved] As Boolean, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim setApprovalForAllFunction = New SetApprovalForAllFunction()
                setApprovalForAllFunction.Operator = [operator]
                setApprovalForAllFunction.Approved = [approved]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of SetApprovalForAllFunction)(setApprovalForAllFunction, cancellationToken)
        
        End Function
        Public Function SupportsInterfaceQueryAsync(ByVal supportsInterfaceFunction As SupportsInterfaceFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of Boolean)
        
            Return ContractHandler.QueryAsync(Of SupportsInterfaceFunction, Boolean)(supportsInterfaceFunction, blockParameter)
        
        End Function

        
        Public Function SupportsInterfaceQueryAsync(ByVal [interfaceId] As Byte(), ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of Boolean)
        
            Dim supportsInterfaceFunction = New SupportsInterfaceFunction()
                supportsInterfaceFunction.InterfaceId = [interfaceId]
            
            Return ContractHandler.QueryAsync(Of SupportsInterfaceFunction, Boolean)(supportsInterfaceFunction, blockParameter)
        
        End Function


        Public Function SymbolQueryAsync(ByVal symbolFunction As SymbolFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Return ContractHandler.QueryAsync(Of SymbolFunction, String)(symbolFunction, blockParameter)
        
        End Function

        
        Public Function SymbolQueryAsync(ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            return ContractHandler.QueryAsync(Of SymbolFunction, String)(Nothing, blockParameter)
        
        End Function



        Public Function TokenURIQueryAsync(ByVal tokenURIFunction As TokenURIFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Return ContractHandler.QueryAsync(Of TokenURIFunction, String)(tokenURIFunction, blockParameter)
        
        End Function

        
        Public Function TokenURIQueryAsync(ByVal [tokenId] As BigInteger, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Dim tokenURIFunction = New TokenURIFunction()
                tokenURIFunction.TokenId = [tokenId]
            
            Return ContractHandler.QueryAsync(Of TokenURIFunction, String)(tokenURIFunction, blockParameter)
        
        End Function


        Public Function TransferFromRequestAsync(ByVal transferFromFunction As TransferFromFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of TransferFromFunction)(transferFromFunction)
        
        End Function

        Public Function TransferFromRequestAndWaitForReceiptAsync(ByVal transferFromFunction As TransferFromFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of TransferFromFunction)(transferFromFunction, cancellationToken)
        
        End Function

        
        Public Function TransferFromRequestAsync(ByVal [from] As String, ByVal [to] As String, ByVal [tokenId] As BigInteger) As Task(Of String)
        
            Dim transferFromFunction = New TransferFromFunction()
                transferFromFunction.From = [from]
                transferFromFunction.To = [to]
                transferFromFunction.TokenId = [tokenId]
            
            Return ContractHandler.SendRequestAsync(Of TransferFromFunction)(transferFromFunction)
        
        End Function

        
        Public Function TransferFromRequestAndWaitForReceiptAsync(ByVal [from] As String, ByVal [to] As String, ByVal [tokenId] As BigInteger, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim transferFromFunction = New TransferFromFunction()
                transferFromFunction.From = [from]
                transferFromFunction.To = [to]
                transferFromFunction.TokenId = [tokenId]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of TransferFromFunction)(transferFromFunction, cancellationToken)
        
        End Function
        Public Function UpdateListPriceRequestAsync(ByVal updateListPriceFunction As UpdateListPriceFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of UpdateListPriceFunction)(updateListPriceFunction)
        
        End Function

        Public Function UpdateListPriceRequestAndWaitForReceiptAsync(ByVal updateListPriceFunction As UpdateListPriceFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of UpdateListPriceFunction)(updateListPriceFunction, cancellationToken)
        
        End Function

        
        Public Function UpdateListPriceRequestAsync(ByVal [listPrice] As BigInteger) As Task(Of String)
        
            Dim updateListPriceFunction = New UpdateListPriceFunction()
                updateListPriceFunction.ListPrice = [listPrice]
            
            Return ContractHandler.SendRequestAsync(Of UpdateListPriceFunction)(updateListPriceFunction)
        
        End Function

        
        Public Function UpdateListPriceRequestAndWaitForReceiptAsync(ByVal [listPrice] As BigInteger, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim updateListPriceFunction = New UpdateListPriceFunction()
                updateListPriceFunction.ListPrice = [listPrice]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of UpdateListPriceFunction)(updateListPriceFunction, cancellationToken)
        
        End Function
    
    End Class

End Namespace

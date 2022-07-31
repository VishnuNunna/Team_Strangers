import Navbar from "./Navbar";
import axie from "../tile.jpeg";
import { useLocation, useParams } from 'react-router-dom';
import MarketplaceJSON from "../Marketplace.json";
import axios from "axios";
import { useState } from "react";
const crypto = require('crypto');

const hash = crypto.getHashes();
const date = new Date();
date.setDate(date.getDate() + 8);

export default function NFTPage (props) {


const customerAddr = "0x9155d7D3455d70811FE8bAe3a827e0f59263c2EF";
const [data, updateData] = useState({});
const [dataFetched, updateDataFetched] = useState(false);
const [message, updateMessage] = useState("");
const [currAddress, updateCurrAddress] = useState("0x");
const [currDate , setcurrDate] = useState("");
const [hashval , sethashval] = useState("");

async function getNFTData(tokenId) {
    const ethers = require("ethers");
   
    const provider = new ethers.providers.Web3Provider(window.ethereum);
    const signer = provider.getSigner();
    const addr = await signer.getAddress();
   
    let contract = new ethers.Contract(MarketplaceJSON.address, MarketplaceJSON.abi, signer)
    
    const tokenURI = await contract.tokenURI(tokenId);
    const listedToken = await contract.getListedTokenForId(tokenId);
    let meta = await axios.get(tokenURI);
    meta = meta.data;
    console.log(listedToken);

    let item = {
        price: meta.price,
        tokenId: tokenId,
        seller: listedToken.seller,
        owner: listedToken.owner,
        image: meta.image,
        name: meta.name,
        description: meta.description,
        waranty:meta.waranty
    }
    console.log("======================");
    
    updateData(item);
    updateDataFetched(true);
    
    updateCurrAddress(addr); 
    
    console.log('date'  , date , typeof(date));
    setcurrDate(date);   
    const haspwd = crypto.createHash('sha1').update(item.tokenId).digest('hex');
    console.log("haspwd" , haspwd);
    sethashval(haspwd);
}

async function buyNFT(tokenId) {
    try {
        const ethers = require("ethers");
        
        const provider = new ethers.providers.Web3Provider(window.ethereum);
        const signer = provider.getSigner();

        
        let contract = new ethers.Contract(MarketplaceJSON.address, MarketplaceJSON.abi, signer);
        const salePrice = ethers.utils.parseUnits(data.price, 'ether')
        updateMessage("Buying the NFT... Please Wait (Upto 5 mins)")
       
        let transaction = await contract.executeSale(tokenId, {value:salePrice});
        await transaction.wait();

        alert('You successfully bought the NFT!');
        updateMessage("");

        setTimeout(
        alert('You received the product sucessfully!') , 
        4000);       ;
        
    }
    catch(e) {
        alert("Upload Error"+e)
    }
}

    const params = useParams();
    const tokenId = params.tokenId;
    if(!dataFetched)
        getNFTData(tokenId);

    return(
        <div style={{"min-height":"100vh"}}>
            <Navbar></Navbar>
            <div className="flex ml-20 mt-20">
                <img src={data.image} alt="" className="w-2/5" />
                <div className="text-xl ml-20 space-y-8 bg-slate-400 shadow-2xl rounded-lg border-2 p-5">
                    <div>
                        Name: {data.name}
                    </div>
                    <div>
                        Serialnumber: {hashval}
                    </div>
                    <div>
                        Description: {data.description}
                    </div>
                    <div>
                        Price: <span className="">{data.price + " ETH"}</span>
                    </div>
                    <div>
                        Companyaddress: <span className="text-sm">{data.owner}</span>
                    </div>
                    <div>
                        Owner: <span className="text-sm">{data.seller}</span>
                    </div>
                    <div>
                        Waranty: <span className="">{data.waranty} days
                        </span>
                    </div>
                    <div >
                    
                    </div>
                    <div>
                
                    {  currAddress==data.owner||currAddress==data.seller||currAddress==0x6CBe0b1323c9dC9d939800355deb89BeEfAA6a11 ?
                           <div className="text-yellow-400">
                       {}

                       {  currAddress!== "0x6CBe0b1323c9dC9d939800355deb89BeEfAA6a11" ?
                          <>
                          <>Warrany ends on : <span>{JSON.stringify(date).slice(1,11)} , {JSON.stringify(date).slice(12,20)}</span></>
                         
                       <h4 >Token tranferred from {data.owner} to 0x6CBe0b1323c9dC9d939800355deb89BeEfAA6a11</h4> 
                       <h4>Token transferred from  0x6CBe0b1323c9dC9d939800355deb89BeEfAA6a11 to {data.seller}</h4> 
                       
                      



                       </> : <> <h4>Token transferred from {data.owner} to 0x6CBe0b1323c9dC9d939800355deb89BeEfAA6a11</h4> 
                       </> }
                                             
                          </div>

                             :<button className="enableEthereumButton bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded text-sm" onClick={() => buyNFT(tokenId)}>Buy this NFT</button>

                    } 

                    {}

                    
                    <div className="text-green text-center mt-3">{message}</div>
                    </div>
                </div>
            </div>
        </div>
    )
}
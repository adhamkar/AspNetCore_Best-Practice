import axios from "axios";

var url = 'http://localhost:5238/api/products';
 const getProducts = async (params = {}) => {
    try{
        const resp=await  axios.get(url,{
            params,
            headers:{
                'Content-Type':'application/json; charset=utf-8'
            }
            
        });
        console.log("the request url is",url);
        console.log(resp.data);
        return resp.data;


    }catch(error){
        console.log(error)
        return [];
    }
};
 const getProduct = async (id: string) => {
};
 const createProduct = async (product: any) => {
};
 const updateProduct = async (id: string, product: any) => {
};
 const deleteProduct = async (id: string) => {
};

export { getProducts,getProduct, createProduct, updateProduct, deleteProduct };
import axios from "axios"


const getCompany = async ({id}:any,{email, name, surrname, token}: any) => {
    let response;
    try{
        response = await axios.get(`http://localhost:5000/company/${id}`,{
            headers : {
                Authorization: `Bearer ${token}`
            }
        })
        console.log(response.data)
        return response.data;   
    } catch (err) {
        console.log(err)
        return {};
    } 
};

export default getCompany;
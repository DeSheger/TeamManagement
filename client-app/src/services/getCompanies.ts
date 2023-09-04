import axios from "axios"


const getCompanies = async ({email, name, surrname, token}: any) => {
    let response;
    try{
        response = await axios.get("http://localhost:5000/company",{
            headers : {
                Authorization: `Bearer ${token}`
            }
        })
        return response.data;   
    } catch (err) {
        console.log(err)
        return {};
    } 
};

export default getCompanies;
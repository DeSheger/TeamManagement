import axios from "axios";


const getCompanyGroups = async (id:any,{email, name, surrname, token}: any) => {
    
    let response;
    try{
        response = await axios.get(`http://localhost:5000/group/companyGroups/${id}`,{
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

export default getCompanyGroups;
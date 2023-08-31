import axios from "axios"

const authenticationService = (token: string) => {
    return axios.get("http://localhost:5000/user",
    {
        headers: {
            Authorization : `Bearer ${token}`
        }
    }
    ).then(() => {
        return true
    }).catch(()=> {
        return false
    })
}

export default authenticationService;
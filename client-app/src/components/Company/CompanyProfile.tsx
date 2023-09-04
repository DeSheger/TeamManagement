import { useEffect, useState } from "react";
import CompanyNavigator from "./CompanyNavigator/CompanyNavigator";
import getCompany from "../../services/getCompany";
import { useSelector } from "react-redux";
import { RootState } from "../../app/store";

const CompanyProfile = ({selectedCompany}:any) => {
    const [company, setCompany] = useState({});
    const session = useSelector((state:RootState) => state.session)

    useEffect(()=>{
        getCompany(selectedCompany.id,session)
            .then((val) => setCompany(val))
            .catch((er) => console.log(er))
        
    },[selectedCompany.id])


    return (
        <div className="companyProfile">
            <header className="companyProfile__header">
                <h2 className="companyProfile__header-name"></h2>
                <p className="companyProfile__header-description"></p>
            </header>
            <section className="companyProfile__main">
                <CompanyNavigator company={company}/>
                    
            </section>
        </div>
    )
}

export default CompanyProfile;
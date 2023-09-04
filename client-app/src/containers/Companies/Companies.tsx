import { useEffect, useState } from "react";
import getCompanies from "../../services/getCompanies";
import { useSelector } from "react-redux";
import { RootState } from "../../app/store";
import CompanyProfile from "../../components/Company/CompanyProfile";


const CompanyIterate = (companies: any, setCompany: Function) => {

    if(companies instanceof Array)
        return companies.map((company:any) => company?<h3 onClick={() => {
            setCompany(company)
        }}>{company.id} {company.name}</h3>
        :null)
    else {
        return "No companies"
    }
}

const Companies = ({theme}:any) => {
    const [companies, setCompanies] = useState([]);
    const session = useSelector((state:RootState)=> state.session)
    const [company, setCompany] = useState({});

    useEffect(() => {
        console.log(session)
        getCompanies(session)
            .then((val) => setCompanies(val))
            .catch((err) => console.log(err))
        console.log(company)
    },[session, company])

    return (
        <div className="companies">
            <div className="companies__sidebar">
                {CompanyIterate(companies, setCompany)}
            </div>
            <section className="companies__content">
                <CompanyProfile selectedCompany={company}/>
            </section>
        </div>
    );
}

export default Companies;
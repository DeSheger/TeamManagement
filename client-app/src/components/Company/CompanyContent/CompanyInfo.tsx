
const CompanyInfo = ({company}:any) => {
    let companyLeader = company?.leader?.name;
    let companyDesc = company?.description;

    
    return (
        <section className="companyInfo">
            <header className="companyInfo__leader">
                {companyLeader}
            </header>
            <div className="companyInfo__desc">
               {companyDesc}
            </div>
        </section>
    )
}

export default CompanyInfo;
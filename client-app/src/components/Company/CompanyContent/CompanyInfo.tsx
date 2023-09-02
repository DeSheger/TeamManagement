
const CompanyInfo = ({leader, descriprion}:any) => {

    return (
        <section className="companyInfo">
            <header className="companyInfo__leader">
                <h3>{`${leader.name} ${leader.surrname}`}</h3>
            </header>
            <div className="companyInfo__desc">
                {descriprion}
            </div>
        </section>
    )
}

export default CompanyInfo;
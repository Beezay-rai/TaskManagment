export default function MyModal({children,open}){
    if(open){
        return(
        
            <div className="modal block animate__fadeInDown  ">
                {children}
            </div>
        )
    }
    else{
        return(
            <div className="modal hidden animate__fadeOutUp">Closed {children}</div>
        )
    }
   
}
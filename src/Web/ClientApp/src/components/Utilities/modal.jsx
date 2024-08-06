export default function MyModal({children,open}){
    if(open){
        return(
        
            <div className="modal">
                {children}
            </div>
        )
    }
    else{
        return(
            <div className="modal">Closed {children}</div>
        )
    }
   
}
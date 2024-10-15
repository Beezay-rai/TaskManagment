import { useEffect, useRef } from 'react';
export default function CollapseItem({state =false,children,onClose}){


  
    return (
      <div  className={`${state ? "block" : "hidden"} `}>
        {children}
      </div>
    );
}
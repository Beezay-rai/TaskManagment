import Link from "next/link";

export default function LinkButton({ url, type, content, className }) {
  return (
    <Link href={url}>
      <button className={className} type={type}>
        {content}
      </button>
    </Link>
  );
}
